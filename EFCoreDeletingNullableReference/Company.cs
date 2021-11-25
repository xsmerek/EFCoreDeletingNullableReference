namespace EFCoreDeletingNullableReference
{
    public partial class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Car Car { get; set; }
    }
}