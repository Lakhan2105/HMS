using System.ComponentModel.DataAnnotations;

namespace ERM.Enums
{
    public enum RolesEnum
    {
        [Display(Name = "ClinicAdmin")]
        clinicAdmin = 1,

        [Display(Name = "Practitioner")]
        practitioner = 2,

        [Display(Name = "Patient")]
        patient = 3,
    }
}
