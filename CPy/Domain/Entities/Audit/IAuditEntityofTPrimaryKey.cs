namespace CPy.Domain.Entities.Audit
{
    public interface IAuditEntity<TPrimaryKey>:IEntity<TPrimaryKey>,ICreate,ISoftDelete,IUpdate
    {
         
    }
}