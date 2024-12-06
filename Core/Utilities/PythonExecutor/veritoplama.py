public class FaceRecognitionService
{
    private readonly YourDbContext _dbContext;
    private readonly PythonExecutor _pythonExecutor;

    public FaceRecognitionService(YourDbContext dbContext)
    {
        _dbContext = dbContext;
        _pythonExecutor = new PythonExecutor();
        _pythonExecutor.InitializePython();
    }

    public async Taskbool RegisterFaceAsync(string username, Stream imageStream)
    {
         Yüz verisini Python'dan al
        byte[] faceEncoding = _pythonExecutor.GetFaceEncoding();

        if (faceEncoding != null)
        {
             Yüz verisini veritabanına kaydetmek için UserFace modelini kullanıyoruz
            var userFace = new UserFace
            {
                Username = username,
                FaceEncoding = faceEncoding
            };

             Veritabanına kaydetme işlemi
            _dbContext.UserFaces.Add(userFace);
            await _dbContext.SaveChangesAsync();

            Console.WriteLine(Yüz verisi veritabanına kaydedildi.);
            return true;
        }

        Console.WriteLine(Yüz verisi alınamadı.);
        return false;
    }

    public void Shutdown()
    {
        _pythonExecutor.ShutdownPython();
    }
}
