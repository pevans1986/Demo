﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Core.Repositories
{
	public class InMemoryRepository<TEntity> : Repository<TEntity>, IRepository<TEntity> 
		where TEntity : IDomainEntity
	{
		#region Private Fields

		// TODO Make thread safe
		private readonly List<TEntity> _data = new List<TEntity>();

		#endregion Private Fields

		#region Public Methods

		public override IRepository<TEntity> Add(TEntity entity)
		{
			if (!Contains(entity))
			{
				_data.Add(entity);
			}

			return this;
		}

		public override bool Contains(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			return Query().Any(item => item.Id == entity.Id);
		}

		public override IRepository<TEntity> Delete(TEntity entity)
		{
			if (_data.Contains(entity))
			{
				_data.Remove(entity);
			}
			else
			{
				_data.RemoveAll(item => item.Id == entity.Id);
			}

			return this;
		}

		public override void Dispose() { }

		public override List<TEntity> GetAll() => _data;

		public override IQueryable<TEntity> Query() => _data.AsQueryable();

		public override IRepository<TEntity> Save(TEntity model)
		{
			var entity = Query().FirstOrDefault(entry => entry.Id == model.Id);
			if (entity != null)
			{
				GetAll().Remove(entity);
			}

			GetAll().Add(model);

			return this;
		}

		public override IRepository<TEntity> SaveChanges() => this;

		public async Task<IRepository<TEntity>> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await Task.Run(() => SaveChanges()).ConfigureAwait(false);
		}

		#endregion Public Methods
	}
}