using MediaPlayerWithTest.src.Domain.Core;

namespace MediaPlayerWithTest.Tests.src.Domain.Tests
{
    public class MediaFileTest
    {
        [Fact]
        public void PlayShouldStartPlayback()
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
        public void PauseShouldPausePlayback()
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
        public void SpeedSetterShouldUpdateSpeedAndRestartPlayback()
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
        public void SpeedSetterWithInvalidSpeedShouldThrowArgumentException(double speed)
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
