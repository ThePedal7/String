public class UnmanagedStringScope : IDisposable {
    public void Dispose() {
        UnmanagedString.Clean();
    }
}
