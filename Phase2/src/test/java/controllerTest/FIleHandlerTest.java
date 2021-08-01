package controllerTest;

import controller.FileHandler;
import model.FileMapper;
import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

@RunWith(MockitoJUnitRunner.class)
public class FIleHandlerTest {
    private FileHandler fileHandler;

    @Mock
    private FileMapper fileMapper;

    @Before
    public void setUp() {
        this.fileHandler = new FileHandler(fileMapper);
    }

    @Test(expected = NullPointerException.class)
    public void initializeTest() {
        fileHandler.initialize("A dir name that doesn't exist");
    }
}
