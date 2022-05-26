from unittest.mock import patch, mock_open
import unittest
from app import FileWriter, get_todos
        
class TestWriteToFile(unittest.TestCase):
    def test_write_to_file(self):
        path = "was/hyper/as/a/kid/cold/as/a/teenager"
        content = "On my mobile calling big shots"
        with patch('app.open', mock_open()) as mocked_file:
            FileWriter().write(path,content)
            mocked_file.assert_called_once_with(path,'w')
            mocked_file().write.assert_called_once_with(content)    
            
class TestAPICall(unittest.TestCase):
    @patch('app.requests.get')
    def test_request(self, mock_get):
        mock_get.return_value.status_code = 200
        response = get_todos()
        self.assertEqual(response.status_code, 200)

if __name__ == '__main__':
    unittest.main()