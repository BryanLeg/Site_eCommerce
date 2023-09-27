namespace SiteECommerce_TP_.DistantData
{
    public class Uploader
    {
        public static string UploadFile(IFormFile file)
        {
            if(file != null && file.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return fileName;
            }
            return "";
        }

    }
}
