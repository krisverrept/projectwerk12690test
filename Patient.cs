using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Netwerk.Models
    {
    public class Patient
    {
        [Key]
    
        [Display(Name = "Netwerk-ID")]
        public int NetwerkId { get; set; }
        public static bool PatientStatus { get; set; }
        [Required, StringLength(15), Display(Name = "Rijksregister")]
        public string NationalNumber { get; set; }
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Display(Name = "Familienaam")]
        public string LastName { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Postcode")]
        public string PostCode { get; set; }

        [Display(Name = "Woonplaats")]
        public string City { get; set; }

        [Display(Name = "Land")]
        public string Country { get; set; }

        [Display(Name = "Geboortedatum")]
        public string BirthDate { get; set; }

        [Display(Name = "Geslacht")]
        public int? GenderId { get; set; }
       
        [Display(Name = "Overlijdensdatum")]
        public string MortalDate { get; set; }

        [Display(Name = "Telefoon")]
        public string PatientPhone { get; set; }

        [Display(Name = "Mail")]
        public string PatientMail { get; set; }

        [Display(Name = "Huisarts")]
        public string HomeDoctor { get; set; }

        [Display(Name = "Huisarts contact")]
        public string ContactHomeDoctor { get; set; }

        [Required, Display(Name = "Behandelend ziekenhuis")]
        public int? IntakeCenterId { get; set; }

        [Display(Name = "Patiënt-ID")]
        public string IntakeNumber { get; set; }

        [Display(Name = "Behandelend arts")]
        public string IntakeDoctor { get; set; }

        [Display(Name = "Contact arts")]
        public string IntakeDoctorMail { get; set; }
        
        [Display(Name = "Datum")]
        public string MocDate { get; set; }
        [Display(Name = "Type Moc")]
        public string MocTypeId { get; set; }
        [Display(Name = "cT")]
        public int CtId { get; set; }
        [Display(Name = "cN")]
        public int CnId { get; set; }
        [Display(Name = "cM")]
        public int CmId { get; set; }
        [Display(Name = "pT")]
        public int PtId { get; set; }
        [Display(Name = "pN")]
        public int PnId { get; set; }
        [Display(Name = "pM")]
        public int PmId { get; set; }
        public string PtnmDate { get; set; }
        public string CtnmDate { get; set; }
        [Display(Name = "Functioneel Syndroom")]
        public string FsValue { get; set; }
        [Display(Name = "Primaire tumor")]
        public string PtValue { get; set; }
        [Display(Name = "Histology primaire tumor")]
        public string HsValue { get; set; }
        [Display(Name = "Beslissing")]
        public string TreatmentDecision { get; set; }
        [Display(Name = "Uitgevoerde therapie(en)")]
        public string TherapyDone { get; set; }
        [Display(Name = "Mediche voorgeschiedenis")]
        public string MedicalHistory { get; set; }
        [Display(Name = "Oncologische voorgeschiedenis")]
        public string OncologyHistory { get; set; }
        [Display(Name = "Huidige ziektebeeld")]
        public string CurrentMedicalDiagnose { get; set; }
        [Display(Name = "Medische beeldvorming")]
        public string MbvValue { get; set; }
        [Display(Name = "Datum")]
        public string MbvDate { get; set; }
        [Display(Name = "Conclusie")]
        public string MbvConclusion { get; set; }
        [Display(Name = "Mutualiteit")]
        public string HealthFund { get; set; }
        public string InitialProblem { get; set; }
        public virtual MocType MocType { get; set; }
        public ICollection<ListMbv> ListMbvs { get; set; }
        public ICollection<ListTnm> ListTnms { get; set; }
        public ICollection<ListFs> ListFses { get; set; }
        public ICollection<ListHs> ListHses { get; set; }
        public ICollection<ListPs> ListPses { get; set; }
        public ICollection<Gender> Genders { get; set; }
        public ICollection<IntakeCenter> IntakeCenters { get; set; }
        public ICollection<Country> Countries { get; set; } 
      
        }

   
    }