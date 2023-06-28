using MediaPlayerWithTest.src.Domain.Core;

namespace MediaPlayerWithTest.Tests.src.Domain.Tests
{
    public class MediaFileTest
    {
        [Fact]
        public void Play_ShouldStartPlayback()
        {
            var testFile = new MediaFile(
                "audio1.mp3",
                "/path/to/file.mp3",
                TimeSpan.FromSeconds(120)
            );

            testFile.Play();

            Assert.True(testFile.IsPlaying);
        }

        [Fact]
        public void Pause_ShouldPausePlayback()
        {
            var testFile = new MediaFile(
                "audio1.mp3",
                "/path/to/file.mp3",
                TimeSpan.FromSeconds(120)
            );

            testFile.Pause();

            Assert.False(testFile.IsPlaying);
        }

        [Fact]
        public void StopShouldStopPlayback()
        {
            var testFile = new MediaFile(
                "audio1.mp3",
                "/path/to/file.mp3",
                TimeSpan.FromSeconds(120)
            );

            testFile.Stop();

            Assert.False(testFile.IsPlaying);
            Assert.Equal(TimeSpan.Zero, testFile.CurrentPosition);
        }

        [Fact]
        public void SpeedSetter_ShouldUpdateSpeed_AndRestartPlayback()
        {
            var testFile = new MediaFile(
                "sample.mp3",
                "/path/to/file.mp3",
                TimeSpan.FromSeconds(120)
            );

            testFile.Play();
            testFile.Speed = 1.5;

            Assert.Equal(1.5, testFile.Speed);
            Assert.True(testFile.IsPlaying);
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(3.5)]
        public void SpeedSetterWithInvalidSpeed_ShouldThrowArgumentException(double speed)
        {
            var testFile = new MediaFile(
                "sample.mp3",
                "/path/to/file.mp3",
                TimeSpan.FromSeconds(120)
            );

            Assert.Throws<ArgumentException>(() => testFile.Speed = speed);
        }
    }
}
