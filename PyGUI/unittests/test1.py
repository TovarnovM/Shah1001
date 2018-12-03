import unittest
from PyGUI import a

class Test_test1(unittest.TestCase):
    def test_A(self):
        self.assertEqual(a, 10)

if __name__ == '__main__':
    unittest.main()
