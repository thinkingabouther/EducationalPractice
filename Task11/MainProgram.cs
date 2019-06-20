using System;

namespace Task11
{
    internal class MainProgram
    {
        public static void Main(string[] args)
        {
            var processor = new MatrixProcessor();
            processor.UploadMatrix("/Users/arsenyneustroev/RiderProjects/EducationalPractice/Task11/TestingData/keyMatrix.txt"); // initializing key matrix
            
            var encodedMatrix = processor.EncodeMessage(FileSystemManager.ReadMessage(
                "/Users/arsenyneustroev/RiderProjects/EducationalPractice/Task11/TestingData/messageToEncode.txt"));
            FileSystemManager.WriteMessage("/Users/arsenyneustroev/RiderProjects/EducationalPractice/Task11/TestingData/encodedMessage.txt", encodedMatrix); // encoding input message and writing it in file
            
            char[,] encodedMatrixFromFile = FileSystemManager.ReadCharMatrix("/Users/arsenyneustroev/RiderProjects/EducationalPractice/Task11/TestingData/encodedMessage.txt"); // getting encoded message from file
            
            string encodedMessageFromFile = "";
            
            for (int i = 0; i < 10; i++) // transforming encoded message to basic string
            {
                for (int j = 0; j < 10; j++)
                {
                    encodedMessageFromFile += encodedMatrixFromFile[i, j];
                }
            }
            
            FileSystemManager.WriteMessage("/Users/arsenyneustroev/RiderProjects/EducationalPractice/Task11/TestingData/decodedMessage.txt", processor.DecodeMessage(encodedMessageFromFile)); // decoding message and writing it in file
        }
    }
}
