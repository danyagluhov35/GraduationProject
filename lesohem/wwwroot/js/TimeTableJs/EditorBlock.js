
// При нажатии на кнопку "отмена", закрывается открывшиеся окно
document.querySelector(".cancel").addEventListener("click", async (e) => {
    var window = document.querySelector(".add-block")
    window.parentElement.removeChild(window)
})
// При нажатии на кнопку "сохранить", вызываем функцию, которая обработает, и внесет данные в блок
document.querySelector(".save").addEventListener("click", async (e) => {
    const nameBlockValue = document.querySelector(".print-name-block input").value
    createBlock()
})

async function createBlock() {
    var block = document.querySelector(".timeTable")

    const timeTable_block = document.createElement("div")
    timeTable_block.classList.add("timeTable-block")
    const p = document.createElement("p")
    const text = document.createTextNode(name)

    const a = document.createElement("a")
    a.href = "#"
    const img = document.createElement("img")
    img.setAttribute("src", "/image/download_icon_251261 (1) 1.png")
    timeTable_block.appendChild(p)
    p.appendChild(text)
    timeTable_block.appendChild(a)
    a.appendChild(img)

    a.setAttribute("style", "cursor:pointer")
    SaveBlock(timeTable_block.innerHTML)
}

async function SaveBlock(timeTable_block) {
    const nameBlock = document.querySelector(".print-name-block input").value
    const file = document.querySelector(".fileTable").files
    const formData = new FormData()
    const elements = {
        ElementDiv: timeTable_block,
        Name : nameBlock
    }
    formData.append("Elements", JSON.stringify(elements))
    formData.append("File", file[0])
    var response = await fetch("/Admin/TimeTable/Save", {
        method: "POST",
        body: formData
    })
    if (response.ok == true) {

    }
}
async function GetBlock() {
    var response = await fetch("/Admin/TimeTable/GetContent", {
        method : "GET"
    })
    if (response.ok == true) {

    }
}
