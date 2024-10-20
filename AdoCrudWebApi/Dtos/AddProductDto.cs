namespace AdoCrudWebApi.Dtos
{
    public class AddProductDto
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
