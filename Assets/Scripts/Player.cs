using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public int lives;
	public float speed;
	public Animator anim;
	void Start () {
		
	}
	void Update ()
	{   //pega os inputs 1, 0 ou -1;
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Vector2 direction = new Vector2(x,y).normalized;

		Movement(direction);
		
		
	}

	void Movement(Vector2 direction)
	{//os quatro limites da tela, esquerda, direia, cima e baixo;
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
	// max da tela somados ou subtraidos a metada do tamanho da nave , para não ultrapassar metade dela para fora;
		max.x = max.x - 0.7f;
		min.x = min.x + 0.7f;

		max.y = max.y - 0.3f;
		min.y = min.y + 1.1f;
	//movimentação da nave
		Vector2 pos = transform.position;
		pos += direction * speed * Time.deltaTime;
	//calculo para nao permitir a nave ir para fora da tela;
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);
		//posição nova definida;
		if (direction.y > 0)
		{
			anim.SetBool("IsMovingDown",false);
			anim.SetBool("IsMovingUp",true);
		}else if (direction.y < 0)
		{
			anim.SetBool("IsMovingUp",false);
			anim.SetBool("IsMovingDown",true);
		}
		else
		{
			anim.SetBool("IsMovingUp",false);
			anim.SetBool("IsMovingDown",false);
		}
		transform.position = pos;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		print(other.gameObject);
	}
}
