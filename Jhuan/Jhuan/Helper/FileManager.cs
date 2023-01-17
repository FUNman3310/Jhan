namespace Jhuan.Helper
{
    public class FileManager
    {
        public static string SaveFile(string rootPath,string FolderName,IFormFile file)
        {
            string name = file.FileName;

            name = name.Length>64 ? name.Substring(name.Length-64,64) : name;

            name = Guid.NewGuid().ToString()+name;

            string savePath = Path.Combine(rootPath,FolderName,name);

            using(FileStream fileStream = new FileStream(savePath,FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return name;
        }
    }
}
