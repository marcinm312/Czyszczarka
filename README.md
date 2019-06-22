# Program czyszczący pliki we wskazanych folderach

Aby program zadziałał poprawnie, należy obok pliku wykonywalnego EXE utworzyć dwa pliki:
* Days.txt - definiuje, jak stare pliki ma usuwać program (np. po wpisaniu liczby 32, program usunie pliki starsze niż 32 dni, wystarczy wpisać samą liczbę);
* Directories.txt - definiuje ścieżki, w których mają być usuwane pliki (każda ścieżka w osobnej linii).

Po uruchomieniu pliku wykonywalnego EXE programu, program usuwa pliki według opisanej wyżej konfiguracji. Dodatkowo program generuje pliki logów, zawierające nazwy i ścieżki usuniętych plików.
