using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace LabBench
{
    [TestFixture]
    class FileTests
    {
        List<String> objectFiles = new List<String>();
        List<String> lessonFiles = new List<String>();

        [Test]
        public void SaveObject()
        {
            String filePath = "testFiles/objects/testobjectsave.bin";
            objectFiles.Add(filePath);

            SerializableItem si = new SerializableItem();
            si.conductive = true;
            si.name = "test object";
            Assert.True(si.saveFile(filePath));
        }

        [Test]
        public void LoadObject()
        {
            foreach (String path in objectFiles)
            {
                SerializableItem si = new SerializableItem();
                bool loaded = si.loadFile(path);

                Assert.True(loaded);

                if (loaded)
                    File.Delete(path);

                Assert.AreEqual(si.name, "test object");
                Assert.AreEqual(si.conductive, true);
                Assert.AreEqual(si.ferrous, false);
            }
        }

        [Test]
        public void SaveLesson()
        {
            String filePath = "testFiles/objects/testobjectsave.bin";
            lessonFiles.Add(filePath);

            language.Icon testIcon = new language.Icon(10.0, 15.0, 90.0, new System.Windows.Media.Imaging.BitmapImage());

            SerializedLesson sl = new SerializedLesson();
            sl.mObjects.Add(testIcon);
            Assert.True(sl.saveFile(filePath));
        }

        [Test]
        public void LoadLesson()
        {
            foreach (String path in lessonFiles)
            {
                SerializedLesson sl = new SerializedLesson();
                bool loaded = sl.loadFile(path);

                Assert.True(loaded);

                if (loaded)
                    File.Delete(path);

                Assert.AreEqual(sl.mObjects.First().getX(), 10.0);
                Assert.AreEqual(sl.mObjects.First().getY(), 15.0);
            }
        }
    }
}
