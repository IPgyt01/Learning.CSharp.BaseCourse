using System;
using System.IO;

namespace Norbit.CRM.Tyganov.Practic9.FilesAndFolders
{
    /// <summary>
    /// Класс для побитового копирования.
    /// </summary>
    class BitwiseCopier
    {
        /// <summary>
        /// Событие начала копирования.
        /// </summary>
        public Action StartCopy;
        
        /// <summary>
        /// Событие окончания копирования.
        /// </summary>
        public Action EndCopy;
        
        /// <summary>
        /// Событие процесса копирования.
        /// </summary>
        public EventHandler<string> ProgressCopy;

        /// <summary>
        ///  Реализация побитового блочного копирования.
        /// </summary>
        /// <param name="source">Путь файла источника.</param>
        /// <param name="destination">Путь файла назначиения.</param>
        /// <param name="clusterLength">Размер блока.</param>
        public void Copy(string source, string destination, int clusterLength)
        {
            if (!File.Exists(source))
            {
                throw new FileNotFoundException("Файл, который нужно копировать не найден", source);
            }

            if (!File.Exists(destination))
            {
                File.Create(destination);
            }

            if (clusterLength < 0)
            {
                throw new ArgumentOutOfRangeException("Длина блока не может быть отрицательной.");
            }

            // Создаем объект поступающего потока (Поток с информацией из файла).
            using (var inputStream = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                // Создаем объект выходного потока (Поток с информацией для записи в файл).
                using (var outputStream = new FileStream(destination, FileMode.Truncate, FileAccess.Write))
                {
                    StartCopy?.Invoke();
                    // Кластер - массив байт необходимого размера.
                    var cluster = new byte[clusterLength];
                    // Количество байт в текущей итерации.
                    var currentClusterLenght = 0;
                    // Количество байт уже скопированных.
                    var numberOfCopied = 0;
                    while ((currentClusterLenght = inputStream.Read(cluster, 0, clusterLength)) > 0)
                    {
                        numberOfCopied += currentClusterLenght;
                        var percent = numberOfCopied * 100.0 / inputStream.Length;
                        
                        // Непосредственно копирование.
                        outputStream.Write(cluster, 0, currentClusterLenght);

                        if (percent < 100)
                        {
                            ProgressCopy?.Invoke(this, $"{(int)percent}%");
                        }
                    }
                    EndCopy?.Invoke();
                }
            }
        }
    }
}
