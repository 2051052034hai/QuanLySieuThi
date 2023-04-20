namespace QuanLySieuThi.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Bills = new HashSet<Bill>();
        }

        public Employee(string employeeName, string employeeAddress, string phone, string userName, string password, string role)
        {
            EmployeeName = employeeName;
            EmployeeAddress = employeeAddress;
            Phone = phone;
            UserName = userName;
            Password = password;
            Role = role;
        }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [StringLength(100)]
        public string EmployeeAddress { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(10)]
        public string Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
