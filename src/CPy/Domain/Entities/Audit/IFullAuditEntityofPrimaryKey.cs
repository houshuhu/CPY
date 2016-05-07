namespace CPy.Domain.Entities.Audit
{
    public interface IFullAuditEntity<TPrimaryKey>:ICreate,ISoftDelete,IUpdate,IEntity<TPrimaryKey>
    {
        TPrimaryKey CreateUserId { get; set; }
        TPrimaryKey UpdateUserId { get; set; }
        TPrimaryKey DeleteUserId { get; set; }
    }
}