from urllib.parse import urljoin
import requests

class FileWriter:
    #@staticmethod
    def write(self,file_path, content):
        with open(file_path, 'w') as file:
            file.write(content)
            
BASE_URL = 'http://jsonplaceholder.typicode.com'
TODOS_URL = urljoin(BASE_URL, 'todos')

def get_todos():
    response = requests.get(TODOS_URL)
    if response.ok:
        return response
    else:
        return None
    
def main():
    print('Making API request')
    content = get_todos()
    print('Received response')
    print('Writing to file')
    FileWriter.write( FileWriter(),'./program_output.txt', content.text)
    print('Done')


if __name__ == '__main__':
    main()