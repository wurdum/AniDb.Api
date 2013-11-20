import os
import re
import shutil

FILESDIR = 'Responses'
ERRORSDIR = 'Errors'


def main():
    def show_errors(failed):
        errors = set()
        for f in failed:
            with open(os.path.join(FILESDIR, f), 'r') as x:
                for line in x:
                    errors.add(line)

        for e in errors:
            print e


    def copy_errors_xmls(ids):
        if not os.path.exists(ERRORSDIR):
            os.mkdir(ERRORSDIR)

        for id in ids:
            file_name = 'anime-%s.xml' % id
            shutil.copy2(os.path.join(FILESDIR, file_name), os.path.join(ERRORSDIR, file_name))


    failed = [f for f in os.listdir(FILESDIR)
              if os.path.isfile(os.path.join(FILESDIR, f)) and f.endswith('fail')]

    rx = re.compile('anime-(?P<aid>\d{1,5})\.xml\.fail')
    ids = [rx.match(f).groupdict()['aid'] for f in failed]

    show_errors(failed)
    copy_errors_xmls(ids)

if __name__ == '__main__':
    main()