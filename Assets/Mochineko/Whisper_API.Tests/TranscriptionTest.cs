#nullable enable
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Mochineko.Whisper_API.Tests
{
    [TestFixture]
    internal sealed class TranscriptionTest
    {
        [Test]
        [RequiresPlayMode(false)]
        public async Task Transcribe()
        {
            // This file is a target of .gitignore.
            var apiKeyPath = Path.Combine(
                Application.dataPath,
                "Mochineko/Whisper_API.Tests/OpenAI_API_Key.txt");

            var apiKey = await File.ReadAllTextAsync(apiKeyPath);

            var filePath = Path.Combine(
                Application.dataPath,
                "Mochineko/Whisper_API.Tests/test.wav");

            using var httpClient = new System.Net.Http.HttpClient();

            var result = await Transcription
                .TranscribeFromFileAsync(
                    apiKey,
                    httpClient,
                    filePath,
                    Model.Whisper1,
                    CancellationToken.None);

            string.IsNullOrEmpty(result).Should().BeFalse();

            var json = TranscriptionResponseBody.FromJson(result);

            Debug.Log($"Result:\n{json?.Text}");
        }
    }
}