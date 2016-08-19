# JsonEtl

**JsonEtl** is a command line program, designed to allow you to read a directory or directory tree full of JSON files, do some kind of filtering/transformation on each record, and then write the result in a CSV format to STDOUT or a file. ETL stands for Extract, Transform, Load.

To write your own transformer function (which you would want to do for this to be helpful) you currently have to modify the source code. I would eventually like to make this injectable in some way.

## Setup

 * Clone the project and open in Visual Studio 2012+
 * Right-click the Solution and click 'Enable NuGet Package Restore'
 * Build the solution
 
## Docs

### Command Line Args

  -p, --path         Required. Path to get files from.

  -f, --filter       (Default: *.json) Filter for files to include.

  -r, --recursive    (Default: False) Get files recursively rather than using
                     the top directory only.

  -o, --outfile      (Default: ) Output results to this file path instead of
                     printing to console

  -e, --echo         (Default: False) Echo the pre-transformed records as CSVs

  --help             Display this help screen.


More docs to come...

## License

Released unencumbered into the public domain under the UNLICENSE 