using System;
using System.Collections.Generic;
using System.Reflection;

namespace GtkWidgetExtensions
{
    public static class Extensions
    {
        /// <summary>Clone is an extension method for Gtk.Widget objects.
        /// <para>Obtain a visually cloned Gtk.Widget object from the current Gtk.Widget object.</para>
        /// <para>The underlying method this feature relies on is largely a work in progress and will need to be extended to include specialized Gtk.Widget objects in order to work as intended in a program that seeks to use this method against those objects.</para>
        /// </summary>
        public static Gtk.Widget Clone (this Gtk.Widget currentWidget)
        {
            // Clone the top-level widget to be the start of the Gtk.Widget tree of cloned members.
            Gtk.Widget widgetTree = null;
            // Keep track of the current cloned Gtk.Widget's parent Gtk.Widget.
            Gtk.Widget currentClonedParentWidget = null;
            // Keep track of all cloned Gtk.Widget's as parents. Add them as they come in; remove them as they are no longer needed.
            List<Gtk.Widget> clonedParentStack = new List<Gtk.Widget> ();
            // Prepare the stack to hold the widget's children (if it's a Gtk.Container).
            List<List<Gtk.Widget>> childListStack = new List<List<Gtk.Widget>> () {new List<Gtk.Widget>(){currentWidget}};
            // Iterate over the child stack, adding new children as they're encountered, until there are no children left.
            while (childListStack.Count > 0) {
                // Consume the last item in the child list stack.
                List<Gtk.Widget> childStack = childListStack [childListStack.Count - 1];
                // If there is nothing in the list, remove it and be done with it.
                if (childStack.Count == 0) {
                    childListStack.RemoveAt (childListStack.Count - 1);
                    // Get rid of the reference to the cloned Gtk.Widget when we're through with it; doesn't exist for top-level.
                    if (clonedParentStack.Count > 0)
                        clonedParentStack.RemoveAt (clonedParentStack.Count - 1);
                } else {
                    // Otherwise, update what is considered the parent.
                    currentWidget = childStack [0];
                    // Then, remove the first item of the child stack.
                    childStack.RemoveAt (0);
                    // Prepare a place for this clone of the current widget to be stored in case it needs to be kept as a parent for the future.
                    Gtk.Widget thisPotentialParentWidget = null;
                    if (widgetTree == null) {
                        // If there is no cloned parent to put Gtk.Widget objects into, then this is the start of the whole tree.
                        thisPotentialParentWidget = widgetTree = CloneTopLevelWidget (currentWidget);
                    } else {
                        // Get the current target to add this current cloned Gtk.Widget to.
                        currentClonedParentWidget = clonedParentStack [clonedParentStack.Count - 1];
                        // Clone the top-level widget (and just the top-level widget).
                        thisPotentialParentWidget = CloneTopLevelWidget (currentWidget);
                        // Add it.
                        (currentClonedParentWidget as Gtk.Container).Add (thisPotentialParentWidget);
                        // If the actual parent Gtk.Widget is either a Gtk.HBox or a Gtk.VBox, then the child needs to be positioned.
                        if (currentWidget.Parent != null && currentClonedParentWidget is Gtk.Box) {
                            // Reference the Gtk.Widget above the current real Gtk.Widget.
                            Gtk.Box box = currentWidget.Parent as Gtk.Box;
                            // Reference the current real Gtk.Widget as a Gtk.Box.BoxChild.
                            Gtk.Box.BoxChild child = box [currentWidget] as Gtk.Box.BoxChild;
                            // Reference the place it was already added to.
                            Gtk.Box clonedBox = currentClonedParentWidget as Gtk.Box;
                            // Get it back out as a Gtk.Box.BoxChild object.
                            Gtk.Box.BoxChild clonedChild = clonedBox [thisPotentialParentWidget] as Gtk.Box.BoxChild;
                            clonedChild.Position = child.Position;
                            clonedChild.Expand = child.Expand;
                            clonedChild.Fill = child.Fill;
                            clonedChild.Padding = child.Padding;
                            clonedChild.PackType = child.PackType;
                        }
                    }
                    // If the parent can have children, they need to be added to the child List Stack (so that the loop continues).
                    if (thisPotentialParentWidget != null && currentWidget != null && currentWidget is Gtk.Container) {
                        //
                        Gtk.Container parentContainer = currentWidget as Gtk.Container;
                        // If the parent has children, add them to the list.
                        if (parentContainer.Children.Length > 0) {
                            // Because the current Gtk.Widget has children, push the cloned Gtk.Widget to the stack for future use.
                            clonedParentStack.Add (thisPotentialParentWidget);
                            // Then, prepare to push references to all the real children into the child stack.
                            List<Gtk.Widget> newList = new List<Gtk.Widget> ();
                            for (int r = 0; r < parentContainer.Children.Length; r++) {
                                newList.Add (parentContainer.Children [r]);
                            }
                            // Push references to all real children of the current Gtk.Widget into the child stack to be consumed.
                            childListStack.Add (newList);
                        }
                    }
                }
            }
            // Send the cloned tree out.
            return widgetTree;
        }

        private static Gtk.Widget CloneTopLevelWidget (Gtk.Widget widget)
        {
            // Prepare a place for the cloned Gtk.Widget.
            Gtk.Widget resultingWidget = null;
            // If there is a widget to clone, then create it by going from GetType() to constructor.
            if (widget != null) {
                // Get the Gtk.Widget's actual type.
                System.Type type = widget.GetType ();
                // If the Gtk.Widget is derived from the Gtk.Container class, create it here. Organization only.
                if (widget is Gtk.Container) {
                    if (type == typeof(Gtk.HBox)) {
                        Gtk.HBox thisWidget = widget as Gtk.HBox;
                        resultingWidget = new Gtk.HBox (
                            thisWidget.Homogeneous,
                            thisWidget.Spacing
                        );
                    } else if (type == typeof(Gtk.VBox)) {
                        Gtk.VBox thisWidget = widget as Gtk.VBox;
                        resultingWidget = new Gtk.VBox (
                            thisWidget.Homogeneous,
                            thisWidget.Spacing
                        );
                    } else if (type == typeof(Gtk.Button)) {
                        Gtk.Button thisWidget = widget as Gtk.Button;
                        // Only use the default constructor. The Gtk.Widget's created by specialized constructors are covered by the regular tree traversal method.
                        resultingWidget = new Gtk.Button ();
                        (resultingWidget as Gtk.Button).Relief = thisWidget.Relief;
                        (resultingWidget as Gtk.Button).Xalign = thisWidget.Xalign;
                        (resultingWidget as Gtk.Button).Yalign = thisWidget.Yalign;
                    } else if (type == typeof(Gtk.EventBox)) {
                        Gtk.EventBox thisWidget = widget as Gtk.EventBox;
                        resultingWidget = new Gtk.EventBox ();
                        (resultingWidget as Gtk.EventBox).AboveChild = thisWidget.AboveChild;
                        (resultingWidget as Gtk.EventBox).VisibleWindow = thisWidget.VisibleWindow;
                    } else if (type == typeof(Gtk.Alignment)) {
                        Gtk.Alignment thisWidget = widget as Gtk.Alignment;
                        resultingWidget = new Gtk.Alignment (
                            thisWidget.Xalign,
                            thisWidget.Yalign,
                            thisWidget.Xscale,
                            thisWidget.Yscale
                        );
                        (resultingWidget as Gtk.Alignment).BottomPadding = thisWidget.BottomPadding;
                        (resultingWidget as Gtk.Alignment).LeftPadding = thisWidget.LeftPadding;
                        (resultingWidget as Gtk.Alignment).RightPadding = thisWidget.RightPadding;
                        (resultingWidget as Gtk.Alignment).TopPadding = thisWidget.TopPadding;
                    }
                } else {
                    if (type == typeof(Gtk.Label)) {
                        Gtk.Label thisWidget = widget as Gtk.Label;
                        // If the Gtk.Label is blank, use the default constructor.
                        if (string.IsNullOrEmpty (thisWidget.LabelProp))
                            resultingWidget = new Gtk.Label ();
                        else {
                            // Otherwise, if the Gtk.Label has text but does not use GTK markup, then use the text-only constructor.
                            if (!thisWidget.UseMarkup)
                                resultingWidget = new Gtk.Label (thisWidget.LabelProp);
                            else {
                                // Failing that, use the Gtk.Label's text as GTK markup.
                                resultingWidget = new Gtk.Label (thisWidget.LabelProp);
                                (resultingWidget as Gtk.Label).Markup = thisWidget.LabelProp;
                            }
                        }
                    } else if (type == typeof(Gtk.Image)) {
                        Gtk.Image thisWidget = widget as Gtk.Image;
                        // If the Gtk.Image has an Gdk.Image in its image property, then retrieve it.
                        if (thisWidget.ImageProp != null) {
                            Gdk.Image thisImage = null;
                            Gdk.Pixmap thisPixmap = null;
                            thisWidget.GetImage (out thisImage, out thisPixmap);
                            resultingWidget = new Gtk.Image (thisImage, thisPixmap);
                        } else if (!string.IsNullOrEmpty (thisWidget.Stock)) {
                            // Otherwise, if the Gtk.Image is based off of a Gtk.Stock image, get the Gtk.Stock string and call the constructor.
                            resultingWidget = new Gtk.Image (
                            thisWidget.Stock,
                            (Gtk.IconSize)thisWidget.IconSize
                            );
                        } else if (!string.IsNullOrEmpty (thisWidget.File)) {
                            // Otherwise, if the Gtk.Image is based off of a filesystem resource, get the filesystem resource path and call the constructor.
                            resultingWidget = new Gtk.Image (thisWidget.File);
                        } else {
                            // Failing all that, use the default constructor.
                            resultingWidget = new Gtk.Image ();
                        }
                    }
                }
                // If the cloned Gtk.Widget is not null, then take care of the Gtk.Widget-level properties and the GLib.Object signals (events).
                if (resultingWidget != null) {
                    // Gtk.Widget-level properties.
                    resultingWidget.AppPaintable = widget.AppPaintable;
                    resultingWidget.CanDefault = widget.CanDefault;
                    resultingWidget.CanFocus = widget.CanFocus;
                    resultingWidget.Direction = widget.Direction;
                    resultingWidget.Events = widget.Events;
                    resultingWidget.ExtensionEvents = widget.ExtensionEvents;
                    resultingWidget.Name = string.Format ("{0}Clone", widget.Name);
                    resultingWidget.NoShowAll = widget.NoShowAll;
                    resultingWidget.Sensitive = widget.Sensitive;
                    // Copy the GLib.Object signals (events) from the real Gtk.Widget to the cloned Gtk.Widget.
                    CopyGLibObjectEvents (widget, resultingWidget);
                } 
            }
            //Console.WriteLine ((resultingWidget == null) ? "CAUTION: Sending back NULL. Should have been " + widget.GetType () : "Sending back Gtk.Widget of type " + resultingWidget.GetType ());
            resultingWidget.QueueResize ();
            return resultingWidget;
        }

        private static void CopyGLibObjectEvents (Gtk.Widget widget, Gtk.Widget resultingWidget)
        {
            // Get the default behavior handlers.
            FieldInfo after_signals = typeof(GLib.Object).GetField (
                "after_signals",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly
            );
            // Get the non-default behavior handlers. Speculation: delegate methods retain GLib.ConnectBefore attribute.
            FieldInfo before_signals = typeof(GLib.Object).GetField (
                "before_signals",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly
            );
            // Prepare the list of fields 0 to 2 fields.
            List<FieldInfo> availableList = new List<FieldInfo> ();
            if (after_signals != null) 
                availableList.Add (after_signals);
            if (before_signals != null)
                availableList.Add (before_signals);
            // Consume each fields events.
            foreach (FieldInfo field in availableList) {
                System.Collections.Hashtable h = (System.Collections.Hashtable)field.GetValue (widget);
                if (h != null) {
                    foreach (var v in h.Keys) {
                        string key = (string)v;
                        if (h [key] != null) {
                            object handler = h [key];
                            switch ((string)key) {
                            case "expose_event":
                                {
                                    resultingWidget.ExposeEvent += (Gtk.ExposeEventHandler)handler;
                                    break;
                                }
                            case "realize":
                                {
                                    resultingWidget.Realized += (System.EventHandler)handler;
                                    break;
                                }
                            case "button_press_event":
                                {
                                    resultingWidget.ButtonPressEvent += (Gtk.ButtonPressEventHandler)handler;
                                    break;
                                }
                            case "button_release_event":
                                {
                                    resultingWidget.ButtonReleaseEvent += (Gtk.ButtonReleaseEventHandler)handler;
                                    break;
                                }
                            case "child_notify":
                                {
                                    resultingWidget.ChildNotified += (Gtk.ChildNotifiedHandler)handler;
                                    break;
                                }
                            case "client_event":
                                {
                                    resultingWidget.ClientEvent += (Gtk.ClientEventHandler)handler;
                                    break;
                                }
                            case "composited_changed":
                                {
                                    resultingWidget.CompositedChanged += (System.EventHandler)handler;
                                    break;
                                }
                            case "configure_event":
                                {
                                    resultingWidget.ConfigureEvent += (Gtk.ConfigureEventHandler)handler;
                                    break;
                                }
                            case "delete_event":
                                {
                                    resultingWidget.DeleteEvent += (Gtk.DeleteEventHandler)handler;
                                    break;
                                }
                            case "direction_changed":
                                {
                                    resultingWidget.DirectionChanged += (Gtk.DirectionChangedHandler)handler;
                                    break;
                                }
                            case "key_press_event":
                                {
                                    resultingWidget.KeyPressEvent += (Gtk.KeyPressEventHandler)handler;
                                    break;
                                }
                            case "key_release_event":
                                {
                                    resultingWidget.KeyReleaseEvent += (Gtk.KeyReleaseEventHandler)handler;
                                    break;
                                }
                            case "show":
                                {
                                    resultingWidget.Shown += (System.EventHandler)handler;
                                    break;
                                }
                            case "hide":
                                {
                                    resultingWidget.Hidden += (System.EventHandler)handler;
                                    break;
                                }
                            case "destroy_event":
                                {
                                    resultingWidget.DestroyEvent += (Gtk.DestroyEventHandler)handler;
                                    break;
                                }
                            case "focus":
                                {
                                    resultingWidget.Focused += (Gtk.FocusedHandler)handler;
                                    break;
                                }
                            case "event":
                                {
                                    resultingWidget.WidgetEvent += (Gtk.WidgetEventHandler)handler;
                                    break;
                                }
                            case "event_after":
                                {
                                    resultingWidget.WidgetEventAfter += (Gtk.WidgetEventAfterHandler)handler;
                                    break;
                                }
                            case "copy_clipboard":
                                {
                                    if (resultingWidget is Gtk.Label)
                                        (resultingWidget as Gtk.Label).CopyClipboard += (System.EventHandler)handler;
                                    break;
                                }
                            case "clicked":
                                {
                                    if (resultingWidget is Gtk.Button)
                                        (resultingWidget as Gtk.Button).Clicked += (System.EventHandler)handler;
                                    break;
                                }
                            case "pressed":
                                {
                                    if (resultingWidget is Gtk.Button)
                                        (resultingWidget as Gtk.Button).Pressed += (System.EventHandler)handler;
                                    break;
                                }
                            case "released":
                                {
                                    if (resultingWidget is Gtk.Button)
                                        (resultingWidget as Gtk.Button).Released += (System.EventHandler)handler;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}