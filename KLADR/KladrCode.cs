using System;

namespace KLADR
{
    /// <summary>
    /// Структура описывающая запись в KLADR.DBF
    /// </summary>
    public struct KladrCode
    {
        /// <summary>
        /// код субъекта РФ (первый уровень классификации)
        /// </summary>
        public readonly int District;
        /// <summary>
        /// код территориальной принадлежности (второй уровень классификации)
        /// </summary>
        public readonly int Region;
        /// <summary>
        /// код города (третий уровень классификации)
        /// </summary>
        public readonly int Country;
        /// <summary>
        /// код населенного пункта (четвертый уровень классификации)
        /// </summary>
        public readonly int Settlement;
        /// <summary>
        /// признак актуальности, 00 - объект актуален.
        /// </summary>
        public readonly int Update;


        public KladrCode(string code)
        {
            if (code.Length != 13) throw new ArgumentException("неправильная длина кода");
            District = int.Parse(code.Substring(0, 2));
            Region = int.Parse(code.Substring(2, 3));
            Country = int.Parse(code.Substring(5, 3));
            Settlement = int.Parse(code.Substring(8, 3));
            Update = int.Parse(code.Substring(11, 2));
        }

    }
}