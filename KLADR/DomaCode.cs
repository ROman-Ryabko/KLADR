using System;

namespace KLADR
{
    /// <summary>
    /// Структура описывающая запись в DOMA.DBF
    /// </summary>
    public struct DomaCode
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
        /// код улицы
        /// </summary>
        public readonly int Street;
        /// <summary>
        /// код дома
        /// </summary>
        public readonly int Building;
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="code">строка для из бд</param>
        public DomaCode(string code)
        {
            if (code.Length != 19) throw new ArgumentException("неправильная длина кода");
            District = int.Parse(code.Substring(0, 2));
            Region = int.Parse(code.Substring(2, 3));
            Country = int.Parse(code.Substring(5, 3));
            Settlement = int.Parse(code.Substring(8, 3));
            Street = int.Parse(code.Substring(11, 4));
            Building = int.Parse(code.Substring(15, 4));
        }
    }
}