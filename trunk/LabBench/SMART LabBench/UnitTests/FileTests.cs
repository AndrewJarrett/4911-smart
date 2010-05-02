using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace LabBench
{
    /// <summary>
    /// Test Fixture that tests all of the file load and save operations
    /// </summary>
    [TestFixture]
    class FileTests
    {
        List<String> objectFiles = new List<String>();
        List<String> lessonFiles = new List<String>();

        /// <summary>
        /// Tests saving an object from a component
        /// </summary>
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

        /// <summary>
        /// Tests loading an object from disk.
        /// </summary>
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

        /// <summary>
        /// tests saving a lesson to a file
        /// </summary>
        [Test]
        public void SaveLesson()
        {
            String filePath = "testFiles/objects/testobjectsave.bin";
            lessonFiles.Add(filePath);

            // can not instantiate ImagePNG within test context
            //language.Icon testIcon = new language.Icon(new language.ImagePNG("ui/save.png"));

            SerializedLesson sl = new SerializedLesson();
            //sl.mObjects.Add(testIcon.getSerialData());
            Assert.True(sl.saveFile(filePath));
        }

        /// <summary>
        /// Tests loading a lesson from a file.
        /// </summary>
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

                Assert.AreEqual(sl.mObjects.First().x, 10.0);
                Assert.AreEqual(sl.mObjects.First().y, 15.0);
            }
        }
    }
}
