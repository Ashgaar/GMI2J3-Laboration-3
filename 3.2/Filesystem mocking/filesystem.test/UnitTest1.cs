using System.IO.Abstractions.TestingHelpers;
//using System.IO.Abstractions.TestingHelpers.MockFileSystem;
using Xunit;
using filesystem;
using System;
using System.Diagnostics;

namespace filesystem.test
{
    public class FileProcessorTestableShould
    {
        [Fact]
        public void ConvertFirstLine()
        {
            var mockFileSystem = new MockFileSystem();

            var mockInputFile = new MockFileData("yes\nno\nyes");
            
            mockFileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            var sut = new FileProcessorTestable(mockFileSystem);
            sut.ConvertFirstLineToUpper(@"C:\temp\in.txt");

            MockFileData mockOutputFile = mockFileSystem.GetFile(@"C:\temp\in.out.txt");

            string[] outputLines = mockOutputFile.TextContents.Split("\r\n");

            Assert.Equal("YES", outputLines[0]);
            Assert.Equal("no", outputLines[1]);
            Assert.Equal("yes", outputLines[2]);
        }
    }
}