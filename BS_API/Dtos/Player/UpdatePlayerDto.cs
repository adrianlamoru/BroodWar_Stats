namespace BS.Dtos
{
    public class UpdatePlayerDto
    {
        public int PlayerID { get; set; }
        public int RaceID { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int CountryID { get; set; }
        public int Age { get; set; }
    }
}