using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    enum State { Alive, Dying, Transcending }
    State _state = State.Alive;

    protected Rigidbody _rigidbody;
    protected AudioSource _audioSource;
    protected bool _collisionsEnabled = true;

    [SerializeField] float thrust = 250f;
    [SerializeField] float rcsThrust = 250f;
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;

    void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        if(_state == State.Alive)
        {
            ProcessThrust();
            ProcessRotation();
        }

        if(Debug.isDebugBuild)
        {
            ProcessHack();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (_state != State.Alive || !_collisionsEnabled)
            return;

        switch(collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                break;

            case "Fuel":
                // todo
                break;

            case "Finish":
                StartSuccessSequence();
                break;

            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        _state = State.Transcending;
        _audioSource.Stop();
        _audioSource.PlayOneShot(success);
        successParticles.Play();
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        _state = State.Dying;
        _audioSource.Stop();
        _audioSource.PlayOneShot(death);
        deathParticles.Play();
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    protected void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    protected void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex < SceneManager.sceneCountInBuildSettings ? currentSceneIndex : 0);
    }

    protected void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            _audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    protected void ApplyThrust()
    {
        _rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);
        if (!_audioSource.isPlaying)
            _audioSource.PlayOneShot(mainEngine);

        if(!mainEngineParticles.isEmitting)
            mainEngineParticles.Play();
    }

    protected void ProcessRotation()
    {
        _rigidbody.angularVelocity = Vector3.zero; // remove rotation due to physics

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rcsThrust);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rcsThrust);
        }
    }

    protected void ProcessHack()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            _collisionsEnabled = !_collisionsEnabled;
        }
    }
}
