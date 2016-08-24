using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Xml;
using Netwerk.Controllers;

namespace Netwerk.Models
{
    
    public class Moc
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Moc-ID")]
        public int Id { get; set; }
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
        public virtual MocType MocType { get; set; }
        public ICollection<ListMbv> ListMbvs { get; set; }
        public ICollection<ListTnm> ListTnms { get; set; }
        public ICollection<ListFs> ListFses { get; set; }
        public ICollection<ListHs> ListHses { get; set; }
        public ICollection<ListPs> ListPses { get; set; }
        public ICollection<Patient> Patients { get; set; }
        
    }
}