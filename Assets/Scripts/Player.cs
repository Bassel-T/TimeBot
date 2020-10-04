using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpheight;
	bool jumped;
	bool bot;
	bool won;

	public Rigidbody2D rb;
	public BoxCollider2D bc;
	public SpriteRenderer sr;
	LevelManager lm;
	Animator anim;
	AudioSource[] sources;

	public GameObject player;
	public GameObject explode;
	public int playerIndex = 0;

	public byte checkpoint = 1;

	GameUI gu;

	void Awake() {
		gu = GameObject.Find("EventSystem").GetComponent<GameUI>();
		sources = GetComponents<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<BoxCollider2D>();
		lm = GameObject.Find("EventSystem").GetComponent<LevelManager>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		jumped = false;
		bot = false;
		won = false;
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void Start() {
		transform.position = lm.spawnpoints[checkpoint];
	}

	// Update is called once per frame
	void Update() {

		if (!bot && !won && gu.playing) {
			Move();
		}

		if (bot) {
			if (Input.GetKeyDown(KeyCode.LeftShift)) {
				// Destroy all bots on the screen
				Instantiate(explode, transform.position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)), transform);
				sources[0].Play();
			}
		}

		if (transform.position.y < -850) {
			// Bounds check for final stage
			rb.velocity = Vector2.zero;
			transform.position = new Vector2(transform.position.x, -849.2f);
		}
		
		if (Input.GetButtonDown("Cancel")) {
			gu.PauseGame();
		}

		if (Input.anyKeyDown) {
			if (won) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}
	}

	// Move the player
	void Move() {

		if (Input.GetKeyDown(KeyCode.R)) {
			// Reset
			Die();
			return;
		}

		float hspeed = Input.GetAxis("Horizontal");

		if (hspeed != 0) {
			rb.velocity = new Vector2(speed * hspeed, rb.velocity.y);
			if (hspeed < 0) {
				sr.flipX = true;
			} else if (hspeed > 0) {
				sr.flipX = false;
			}
		} else {
			rb.velocity = rb.velocity.y * Vector2.up;
		}

		if (Input.GetButtonDown("Jump") && !jumped) {
			rb.AddForce(Vector2.up * jumpheight, ForceMode2D.Impulse);
			sources[1].Play();
			jumped = true;
		}

	}

	// Begins automation
	public void GeneratePlayer() {

		// Create new player
		if (gameObject.transform.childCount > 0) {
			GameObject p = (GameObject)Instantiate(player, lm.spawnpoints[lm.currLevel], Quaternion.identity);
			p.GetComponent<Player>().checkpoint = checkpoint;
			gameObject.transform.GetChild(0).GetComponent<Destroyer>().DestroyThis();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		// TODO : Check if collision is from below
		if (collision.otherCollider.tag == "Jumpable") {
			if (collision.GetContact(0).point.y < transform.position.y - 0.3f) {
				jumped = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Flag") {
			collision.gameObject.GetComponent<FlagScript>().ChangeState();
			checkpoint++;
		} else if (collision.tag == "Hazard" && !bot) {
			Die();
		} else if (collision.tag == "StageTrigger") {
			lm.NextLevel();
			Destroy(collision.gameObject);
		} else if (collision.tag == "Finish") {
			GameObject.Find("Music").GetComponent<MusicManager>().StopAll();
			Destroy(collision.gameObject);
			won = true;
		}
	}

	void Die() {
		bot = true;
		rb.velocity = Vector2.zero;
		sources[2].Play();
		rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		Invoke("GeneratePlayer", 0.3f);
	}
}
