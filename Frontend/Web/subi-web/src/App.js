import './App.css';
import LoginComponent from "./LoginComponent";

function App() {
  return (
    <div className="App">
      <header className="App-header">
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
