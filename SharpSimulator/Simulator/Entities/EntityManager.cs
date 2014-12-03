using System;
using System.Collections.Generic;

namespace SharpSimulator
{
	public class EntityManager {
		protected List<AEntity> entities;

		public EntityManager() {
			entities = new List<AEntity> ();
		}

		public void Add(AEntity entity) {
			entities.Add (entity);
		}

		public void Move() {
			foreach (var entry in entities) {
				entry.Move ();
			}
		}

		public void Talk() {
			foreach (var entry in entities) {
				TextUtils.OptionalPrint (entry.Talk ());
			}
		}

		public void Fight() {
			foreach (var entry in entities) {
				entry.Fight ();
			}
		}
	}
}

