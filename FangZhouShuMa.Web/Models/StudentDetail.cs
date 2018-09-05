using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace FangZhouShuMa.Web.Models
{
    [DataContract(Name = "student")]
    public class StudentDetail
    {
        [DataMember(Name = "reg_no")]
        public string RegNo { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
        [DataMember(Name = "phone_no")]
        public string PhoneNo { get; set; }
        [DataMember(Name = "admission_date")]
        public DateTime AdmissionDate { get; set; }
    }
}
