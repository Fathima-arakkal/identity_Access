namespace IdClaimsPractice3.Models
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public string SerialNo { get; set; }
        public MachineType MachineType { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }

}
