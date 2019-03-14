﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Domain.ToDo
{
	public class TaskList : IDomainEntity
	{
		#region Public Properties

		public string Description { get; set; }

		public Guid Id { get; set; }

		public virtual List<TaskItem> Items { get; set; }

		public virtual ItemStatus Status { get; set; }

		public string Title { get; set; }

		#endregion Public Properties
	}
}
