using Linq.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public static class Tasks
    {
        #region Low

        /// <summary>
        /// Заданы символ С последовательность непустых строк stringList.
        /// Получить новую последовательность строк из stringList с длиной более одного
        /// символа, начинающихся и заканчивающихся символом C
        /// </summary>
        /// <param name="c"></param>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static IEnumerable<string> Task1(char c, IEnumerable<string> stringList)
        {
            return stringList.Select(x => x).Where(x => x.Length > 1 && x.StartsWith(c) && x.EndsWith(c));
        }

        /// <summary>
        /// Задана последовательность непустых строк stringList.
        /// Получить последовательность отсортированных по возрастанию целых значений,
        /// равных длинам строк, входящих в последовательность stringList.
        /// </summary>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static IEnumerable<int> Task2(IEnumerable<string> stringList)
        {
            return stringList.Select(x => x.Length).OrderBy(x => x);
        }

        /// <summary>
        /// Задана последовательность непустых строк stringList.
        /// Получить новую последовательность строк, где каждая строка состоит из первого и
        /// последнего символов соответствующей строки последовательности stringList.
        /// </summary>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static IEnumerable<string> Task3(IEnumerable<string> stringList)
        {
            return stringList.Select(x => string.Concat(x.First(), x.Last()));
        }

        /// <summary>
        /// Задано целое положительное значение K и последовательность непустых строк stringList.
        /// Строки последовательности содержат только цифры и заглавные буквы латинского алфавита.
        /// Получить из stringList все строки длины K, оканчивающиеся цифрой, и отсортировать их по возрастанию.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList)
        {
            return stringList.Where(x => x.Length == k && char.IsDigit(x.Last())).OrderBy(x => x);
        }

        /// <summary>
        /// Задана последовательность положительных целых значений integerList.
        /// Получить последовательность строковых представлений только нечетных значений
        /// integerList и отсортировать по возрастанию
        /// </summary>
        /// <param name="integerList"></param>
        /// <returns></returns>
        public static IEnumerable<string> Task5(IEnumerable<int> integerList)
        {
            return integerList.Where(x => x % 2 == 1).OrderBy(x => x).Select(x => x.ToString());
        }

        #endregion Low

        #region Middle

        /// <summary>
        /// Заданы последовательность положительных значений numbers и последовательность строк stringList.
        /// Получить новую последовательность строк по следующему правилу:
        /// для каждого значения n из последовательности numbers выбрать строку из последовательности stringList,
        /// начинающуюся с цифры и имеющую длину n.
        /// Если требуемых строк в последовательности stringList несколько - вернуть первую, если их нет, то вернуть строку «Not found»
        /// (Для обработки ситуации, связанной с отсутствием требуемых строк, использовать операцию ??)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList)
        {
            return numbers.Select(x =>
                stringList.FirstOrDefault(y => y.Length == x && char.IsDigit(y.First()))
                ?? "Not found");
        }

        /// <summary>
        /// Задано целое положительное значение K и последовательность целых значений integerList.
        /// Вычислить разность двух подмножеств целых значений: первое подмножество - все
        /// четные значения integerList, второе подмножество - это значения integerList,
        /// исключая первые К элементов.В полученной разности заменить порядок на обратный
        /// </summary>
        /// <param name="k"></param>
        /// <param name="integerList"></param>
        /// <returns></returns>
        public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList)
        {
            return integerList.Where(x => x % 2 == 0)
                              .Except(integerList.Skip(k))
                              .Reverse();
        }

        /// <summary>
        /// Задано целое положительное значение K, целое значение D и последовательность
        /// целых значений integerList.
        /// Вычислить объединение двух подмножеств целых значений: первое подмножество -
        /// все значения integerList до первого элемента, больше чем D(не включая его) , второе
        /// подмножество - это значения integerList, начиная с элемента с порядковым номером К
        /// включительно(нумерация элементов integerList начинается с 0) . Полученную
        /// последовательность отсортировать по убыванию
        /// </summary>
        /// <param name="k"></param>
        /// <param name="d"></param>
        /// <param name="integerList"></param>
        /// <returns></returns>
        public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList)
        {
            return integerList.TakeWhile(x => x <= d)
                              .Union(integerList.Skip(k))
                              .OrderByDescending(x => x);
        }

        /// <summary>
        /// Задана последовательность непустых строк stringList, содержащих только заглавные
        /// буквы латинского алфавита.
        /// Для всех строк, начинающихся с одной и той же буквы, определить их суммарную
        /// длину и получить последовательность строк вида «S-C», где S — суммарная длина
        /// всех строк из stringList, которые начинаются с символа С.Полученную
        /// последовательность упорядочить по убыванию числовых значений сумм, а при равных
        /// значениях сумм — по возрастанию кодов символов C.
        /// </summary>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static IEnumerable<string> Task9(IEnumerable<string> stringList)
        {
            return stringList.GroupBy(x => x.First())
                             .Select(x => new { S = x.Sum(st => st.Length), C = x.Key })
                             .OrderByDescending(x => x.S)
                             .ThenBy(x => (int)x.C)
                             .Select(w => string.Concat(w.S, '-', w.C));
        }

        /// <summary>
        /// Задана последовательность непустых строк символов латинского алфавита stringList.
        /// Среди всех строк одинаковой длины, отсортированных по возрастанию, выбрать у
        /// каждой строки последний символ, переведя его в верхний регистр, и из полученных
        /// символов составить строку.Полученную последовательность строк упорядочить по
        /// убыванию их длин.
        /// </summary>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static IEnumerable<string> Task10(IEnumerable<string> stringList)
        {
            return stringList.OrderBy(x => x)
                             .GroupBy(x => x.Length)
                             .Select(x => string.Concat(x.Select(x => x.ToUpper().Last())))
                             .OrderByDescending(x => x.Length);
        }

        #endregion Middle

        #region Advance

        /// <summary>
        /// Задана последовательность данных об абитуриентах nameList типа Entrant.
        /// Каждый элемент последовательности включает поля <Номер школы> <Год поступления><Фамилия>
        /// Получить данные (список значений YearSchoolStat) о числе различных школ,
        /// которые окончили абитуриенты, для каждого года, присутствующего в исходных данных
        /// Тип YearSchoolStat включает поля<Год поступления > <Количество школ>
        /// Список значений YearSchoolStat должен быть упорядоченным по возрастанию
        /// количества школ, а для совпадающих значений — по возрастанию номера года.
        /// </summary>
        /// <param name="nameList"></param>
        /// <returns></returns>
        public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList)
        {
            return nameList.GroupBy(x => x.Year)
                           .Select(x => new YearSchoolStat()
                           {
                               NumberOfSchools = x.Select(x => x.SchoolNumber).Distinct().Count(),
                               Year = x.Key
                           })
                           .OrderBy(x => x.NumberOfSchools)
                           .ThenBy(x => x.Year);
        }

        /// <summary>
        /// Заданы последовательности положительных целых значений integerList1 и
        /// integerList2; все значения в каждой последовательности различны.
        /// Получить набор (список значений NumberPair) всех пар значений, удовлетворяющих
        /// следующим условиям: первый элемент пары принадлежит последовательности
        /// integerList1, второй принадлежит integerList2, и оба элемента оканчиваются одной и
        /// той же цифрой.
        /// Тип NumberPair включает поля<Значение 1 > < Значение 2 >.
        /// Полученный список NumberPair должен быть отсортирован по возрастанию по
        /// первому полю, а в случае их равенства - по второму
        /// </summary>
        /// <param name="integerList1"></param>
        /// <param name="integerList2"></param>
        /// <returns></returns>
        public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2)
        {
            return integerList1.Join(integerList2, x => x % 10, y => y % 10, (x, y) => new NumberPair()
                                {
                                    Item1 = x,
                                    Item2 = y
                                })
                               .OrderBy(x => x.Item1)
                               .ThenBy(x => x.Item2);
        }

        /// <summary>
        /// Заданы последовательность данных об абитуриентах nameList типа Entrant и
        /// последовательность целых чисел yearList, означающих года.Каждый элемент
        /// последовательности nameList включает поля <Номер школы> <Год поступления> <Фамилия>
        /// Получить данные (список значений YearSchoolStat) о числе различных школ,
        /// которые окончили абитуриенты, для каждого года из списка yearList.
        /// YearSchoolStat включает поля <Год поступления> <Количество школ> . Если в заданный год
        /// поступления абитуриентов из перечисленных школ нет, указать в поле <Количество школ> нуль.
        /// Список YearSchoolStat должен быть упорядоченным по возрастанию
        /// количества школ, а для совпадающих значений — по возрастанию номера года.
        /// </summary>
        /// <param name="nameList"></param>
        /// <param name="yearList"></param>
        /// <returns></returns>
        public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
        {
            return nameList.Where(x => yearList.Contains(x.Year))
                           .GroupBy(x => x.Year)
                           .Select(x => new YearSchoolStat()
                           {
                               NumberOfSchools = x.Select(x => x.SchoolNumber).Distinct().Count(),
                               Year = x.Key
                           })
                           .OrderBy(x => x.NumberOfSchools)
                           .ThenBy(x => x.Year);
        }

        /// <summary>
        /// Заданы последовательность сведений о потребителях supplierList типа Supplier и
        /// последовательность скидок для потребителей в различных магазинах
        /// supplierDiscountList типа SupplierDiscount.Каждый элемент последовательности
        /// supplierList включает поля<Код потребителя>, <Год рождения>, <Улица проживания>.
        /// Каждый элемент последовательности supplierDiscountList включает
        /// поля <Код потребителя>, <Название магазина>, <Скидка (в процентах)>
        /// Получить список (значения MaxDiscountOwner) всех магазинов и для каждого из них
        /// потребителя, имеющего максимальную скидку в этом магазине. Если для некоторого
        /// магазина имеется несколько потребителей с максимальной скидкой, то взять данные о
        /// потребителе с минимальным кодом. Список упорядочивать по названиям магазинов в
        /// алфавитном порядке по возрастанию
        /// </summary>
        /// <param name="supplierList"></param>
        /// <param name="supplierDiscountList"></param>
        /// <returns></returns>
        public static IEnumerable<MaxDiscountOwner> Task14(IEnumerable<Supplier> supplierList,
                IEnumerable<SupplierDiscount> supplierDiscountList)
        {
            return supplierDiscountList.Join(supplierList, x => x.SupplierId, y => y.Id, (x, y) => new
                                        {
                                            discount = x.Discount,
                                            shopName = x.ShopName,
                                            adress = y.Adress,
                                            id = y.Id,
                                            year = y.YearOfBirth
                                        })
                                       .OrderBy(x => x.shopName)
                                       .ThenByDescending(x => x.discount)
                                       .GroupBy(x => x.shopName)
                                       .Select(x => new MaxDiscountOwner()
                                       {
                                           Discount = x.Select(y => y.discount).First(),
                                           ShopName = x.Key,
                                           Owner = new Supplier()
                                           {
                                               Adress = x.Select(y => y.adress).First(),
                                               Id = x.Select(y => y.id).First(),
                                               YearOfBirth = x.Select(y => y.year).First()
                                           }
                                       });
        }

        #endregion Advance
    }
}