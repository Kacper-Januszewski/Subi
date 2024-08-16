import logo from './logo.svg';
import './App.css';
import LoginComponent from "./LoginComponent";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
            //test
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
          <div>
              <a href={"profile.html"}>profile</a>
          </div>
          <div>
              <LoginComponent />
          </div>
      </header>
    </div>
  );
}

export default App;
