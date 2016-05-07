namespace CPy.Domain.Entities
{
    public  class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public  TPrimaryKey Id { get; set; }

    }
}