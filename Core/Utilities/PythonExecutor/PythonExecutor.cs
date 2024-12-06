using Python.Runtime;

public class PythonExecutor
{
	public void InitializePython()
	{
		PythonEngine.PythonHome = @"C:\Users\berka\anaconda3\Lib\site-packages\pyarrow\src\arrow\python"; // Python yüklü olduğunuz dizin
		PythonEngine.Exec("import sys; sys.path.append(r'C:\\Users\\berka\\source\\repos\\WPFGüvenlikSistemi\\Core\\Utilities\\PythonExecutor')"); // Python script dosyanızın yolu
		PythonEngine.Initialize();
	}

	public void ShutdownPython()
	{
		PythonEngine.Shutdown();
	}

	public dynamic ExecutePythonFunction(string moduleName, string functionName, params object[] args)
	{
		using (Py.GIL())
		{
			dynamic pyModule = Py.Import(moduleName);
			dynamic pyFunction = pyModule.GetAttr(functionName);
			return pyFunction.Invoke(args);
		}
	}

	// GetFaceEncoding fonksiyonu, imagePath parametresini almalı
	public byte[] GetFaceEncoding(string imagePath)
	{
		// Python'dan yüz verisini almak için fonksiyonu çağırıyoruz
		dynamic result = ExecutePythonFunction("veritoplama", "get_face_encoding", imagePath);
		return result != null ? result.ToArray() : null;
	}
}
