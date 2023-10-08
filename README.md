# extract-al-app-package

Simple command line tool to extract AL app files. Handles both normal packages and runtime packages.

Dependency `Microsoft.Dynamics.Nav.CodeAnalysis.dll` is not included in the repo.

## Usage

Two arguments are required
1. path to file to extract
2. path to target directory for extraction

```sh
extract-al-app-package.exe file-to-extract.app extract-to-directory
```
