using System.IO;

namespace HttpContextMoq.Tests.Helpers
{
    public class FakeStream : Stream
    {
        private readonly Stream _innerStream;

        public FakeStream(Stream innerStream)
        {
            _innerStream = innerStream;
        }

        public override bool CanRead => throw new System.NotImplementedException();

        public override bool CanSeek => throw new System.NotImplementedException();

        public override bool CanWrite => throw new System.NotImplementedException();

        public override long Length => throw new System.NotImplementedException();

        public override long Position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override void Flush()
        {
            throw new System.NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new System.NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new System.NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        // Implement required abstract methods by delegating to _innerStream
        // Example: public override int Read(byte[] buffer, int offset, int count) => _innerStream.Read(buffer, offset, count);
    }
}
