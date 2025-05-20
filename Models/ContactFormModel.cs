namespace dotnet_store.Models
{
    public class ContactFormModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Captcha { get; set; } // örnek: 6 + 6 sorusu
    }
}