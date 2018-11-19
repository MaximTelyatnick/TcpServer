
namespace TVM_WMS.SERVER.DTO
{
    public class StorageGroupUsersDTO
    {
        public int StorageGroupUserId { get; set; }
        public int UserId { get; set; }
        public int StorageGroupId { get; set; }
        public string StorageGroupName { get; set; }
        public bool CheckForDelete { get; set; }
    }
}
