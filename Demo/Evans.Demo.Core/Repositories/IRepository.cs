﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Evans.Demo.Core.Repositories
{
	public interface IRepository<TModel> : IDisposable
	{
		#region Public Methods

		IRepository<TModel> Add(TModel entity);

		IRepository<TModel> Delete(TModel entity);

		IRepository<TModel> DeleteById(object id);

		TModel Find(params object[] keys);

		TModel FindById(object id);

		List<TModel> GetAll();

		IQueryable<TModel> Query();

		IRepository<TModel> Save(TModel model);

		IRepository<TModel> SaveChanges();

		#endregion Public Methods
	}
}