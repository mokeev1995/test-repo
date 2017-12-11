using System.Collections.Generic;
using System.Linq;

namespace ConfirmitTest.Core.Repositories
{
    public class ListBasedRepository<TEntiy>: BaseRepository<TEntiy>
        where TEntiy: class
    {
        protected readonly List<TEntiy> Storage;

        public ListBasedRepository()
        {
            Storage = new List<TEntiy>();
        }

        public override IQueryable<TEntiy> GetAll()
        {
            return Storage.AsQueryable();
        }

        public override TEntiy Insert(TEntiy entity)
        {
            Storage.Add(entity);
            return entity;
        }

        public override void Delete(TEntiy entity)
        {
            Storage.Remove(entity);
        }
    }
}