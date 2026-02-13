// =====================================================================
// Как собрать и подключить DLL-библиотеку
// =====================================================================
//
// 1) Собираем библиотеку:
//    dotnet build Module6.Task1.Lib
//
//    Результат: Module6.Task1.Lib/bin/Debug/net10.0/Module6.Task1.Lib.dll
//
// 2) Подключение — Способ A: ссылка на проект (ProjectReference)
//    В .csproj приложения добавляем:
//
//    <ItemGroup>
//      <ProjectReference Include="..\Module6.Task1.Lib\Module6.Task1.Lib.csproj" />
//    </ItemGroup>
//
//    Или через командную строку:
//    dotnet add Module6.Task1 reference Module6.Task1.Lib
//
// 3) Подключение — Способ B: ссылка на готовую DLL-файл (Reference)
//    Если есть только .dll без исходников:
//
//    <ItemGroup>
//      <Reference Include="Module6.Task1.Lib">
//        <HintPath>..\path\to\Module6.Task1.Lib.dll</HintPath>
//      </Reference>
//    </ItemGroup>
//
// 4) Собираем и запускаем приложение:
//    dotnet run --project Module6.Task1
// =====================================================================

using Module6.Task1.Lib;

namespace Module6.Task1;

static class Program
{
    static void Main()
    {
        MessageHelper.ShowInfo("Приложение запущено");
        MessageHelper.ShowInfo("Метод вызван из подключённой DLL-библиотеки");
        MessageHelper.ShowInfo("Приложение завершено");
    }
}
