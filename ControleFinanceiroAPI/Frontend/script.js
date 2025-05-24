const API_URL = "http://localhost:5155";


async function carregarCategorias() {
  const resposta = await fetch(`${API_URL}/categorias`);
  const categorias = await resposta.json();

  const lista = document.getElementById("lista-categorias");
  lista.innerHTML = "";

  categorias.forEach(cat => {
    const item = document.createElement("li");
    item.textContent = `#${cat.id} - ${cat.nome}`;
    lista.appendChild(item);
  });
}

document.getElementById("form-categoria").addEventListener("submit", async (e) => {
  e.preventDefault();

  const nome = document.getElementById("input-categoria").value;

  await fetch(`${API_URL}/categorias`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ nome })
  });

  document.getElementById("form-categoria").reset();
  carregarCategorias();
});

carregarCategorias();
