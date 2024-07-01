using System.ComponentModel.DataAnnotations;

namespace ApplicationService.Domain.Entities;

    public class Request
    {
        public int RequestId { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RequestTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }