using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;
using Evans.Demo.Core.Repositories;

using Moq;

using NUnit.Framework;

namespace Evans.Demo.Core.Tests.Repositories
{
	public class Foo : IDomainEntity
	{
		#region Public Properties

		public Guid Id { get; set; } = Guid.NewGuid();

		public string Name { get; set; }

		#endregion Public Properties
	}

	[TestFixture]
	public class InMemoryRepositoryTests
	{
		#region Public Methods

		[Test]
		public void Add_ShouldCheckIfRepositoryContainsEntity()
		{
			var moq = new Mock<InMemoryRepository<Foo>>() { CallBase = true };
			moq.Object.Add(new Foo());

			moq.Verify(m => m.Contains(It.IsAny<Foo>()), Times.Once);
		}

		[Test]
		public void Contains_ShouldCheckBasedOnEntityId()
		{
			var repo = new InMemoryRepository<Foo>();
			var foo = new Foo();
			repo.Add(foo);

			var foo2 = new Foo() { Id = foo.Id };

			Assert.IsTrue(repo.Contains(foo2));
		}

		#endregion Public Methods
	}
}