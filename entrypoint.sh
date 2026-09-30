
set -e


dotnet ef database update --no-build --verbose


dotnet CafeteriaWeb.dll