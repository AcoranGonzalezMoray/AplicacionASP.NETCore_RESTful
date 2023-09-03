namespace BC_Veterinaria.Model
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public DateTime Birth { get; set; }
        public int Age { get; set; }
        public string Pathologies { get; set; }
        public string Vaccinations { get; set; } 
        public string ImageUrl { get; set; }
       
    }
}
